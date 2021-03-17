#include <Adafruit_NeoPixel.h>
#include <EEPROM.h>

/* 
 *  Char - Effect Mappings:
 *  a   -   rainbow
 *  b   -   rainbow fade
 *  c   -   simple color change
 *  d   -   comet
 *  e   -   
 *  f   -   
 *  g   -   
 */

Adafruit_NeoPixel strip1(20, 2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel strip2(20, 6, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel strip3(20, 12, NEO_GRB + NEO_KHZ800);

bool syncMode;
char syncModeEffect;

void setup() 
{
  Serial.begin(9600);
  
  strip1.begin();           // INITIALIZE NeoPixel strip1 object (REQUIRED)
  strip2.begin();
  strip3.begin();
  
  strip1.show();            // Turn OFF all pixels ASAP
  strip2.show();
  strip3.show();
  
  strip1.setBrightness(150); // Set BRIGHTNESS to about 1/5 (max = 255)
  strip2.setBrightness(150);
  strip3.setBrightness(150);
}

void loop() 
{
  updateState();
  updateEffect();

  if(syncMode)
  {
    strip1.show();
    strip2.show();
    strip3.show();  
  }
}

void updateEffect()
{
  if(syncMode)
  {
    switch(syncModeEffect)
    {
      case 'a':
        sync_Rainbow(5, 20);
        break;
      case 'b':
        sync_Rainbow(10, 100);
        break;
      case 'c':
        fire();
        break;
      case 'd':
        comet((0xff,0xff,0xff),10, 64, true, 30);
        break;
    }
  }
}

void updateState()
{
  // input string aufbau -> stripId;effect;
  /* 
   * stripId: 
   *  if 0: all sync  
   *  not 0: id of the strip
   *  
   * effect:
   *  - effectId
   *  
   *  
   *  0;a;       - rainbow
   *  1;255,0,0; - strip 1 red
   */
  
  if(Serial.available() > 0 )
  {
    String input = Serial.readString();

    String stripId = getValue(input, ';', 0);
    Serial.print("Strip id: ");
    Serial.println(stripId[0]);
    
    String effect = getValue(input, ';', 1);
    Serial.print("effect: ");
    Serial.println(effect);

    if(stripId.toInt() == 0)
    {
      // Sync effect
      syncMode = true;
      syncModeEffect = effect[0];
    }
    else
    {
      // Single color
      syncMode = false;
      
      int r = getValue(effect, ',', 0).toInt();
      int g = getValue(effect, ',', 1).toInt();
      int b = getValue(effect, ',', 2).toInt();
      
      switch(stripId.toInt())
      {
        case 1:
          setStripSingleColor(strip1, strip1.Color(r, g, b));
          break;
        case 2:
          setStripSingleColor(strip2, strip1.Color(r, g, b));
          break;
        case 3:
          setStripSingleColor(strip3, strip1.Color(r, g, b));
          break;
      }
    }
  }
}

long sync_Rainbow_currentHue = 0;
void sync_Rainbow(int wait, int effectWidth) 
{
  if(sync_Rainbow_currentHue < 5*65536)
  {
    for(int i=0; i<effectWidth; i++) 
    { 
      int pixelHue = sync_Rainbow_currentHue + (i * 65536L / effectWidth);
      setPixelColorSync(i, strip1.gamma32(strip1.ColorHSV(pixelHue)));
    }
    
    sync_Rainbow_currentHue += 256;
  }
  else
  {
    sync_Rainbow_currentHue = 0;
  }

  delay(wait);
}

void fire()
{
  uint32_t baseColor = strip1.Color(  255,   0,   0);
  uint32_t fireColor = strip1.Color(  250,   135,   0);
  strip1.fill(baseColor, 0, strip1.numPixels());
  strip2.fill(baseColor, 0, strip1.numPixels());
  strip3.fill(baseColor, 0, strip1.numPixels());
  strip1.show();
  strip2.show();
  strip3.show();
  delay(20);
  
  int firePixelCount = strip1.numPixels() / 3;
  int firePixels[firePixelCount];
  for(int i = 0; i < firePixelCount; i++)
  {
    int firePixel = random(0, strip1.numPixels());
    strip1.setPixelColor(firePixel, fireColor);
    strip2.setPixelColor(firePixel, fireColor);
    strip3.setPixelColor(firePixel, fireColor);
    strip1.show();
    strip2.show();
    strip3.show();
  }
  
  delay(100);
}

void comet(uint32_t color, byte meteorSize, byte meteorTrailDecay, boolean meteorRandomDecay, int SpeedDelay)
{
  int numpixels = 24;
  
  fillAllPixels(strip1.Color( 0, 0, 0));
 
  for(int i = 0; i < numpixels+numpixels; i++) 
  {
    for(int j=0; j<numpixels; j++) 
    {
      if( (!meteorRandomDecay) || (random(10)>5) ) 
      {
        uint32_t oldColor;
        uint8_t r, g, b;
        int value;
   
        oldColor = strip1.getPixelColor(j);
        r = (oldColor & 0x00ff0000UL) >> 16;
        g = (oldColor & 0x0000ff00UL) >> 8;
        b = (oldColor & 0x000000ffUL);

        r=(r<=10)? 0 : (int) r-(r*meteorTrailDecay/256);
        g=(g<=10)? 0 : (int) g-(g*meteorTrailDecay/256);
        b=(b<=10)? 0 : (int) b-(b*meteorTrailDecay/256);
   
        setPixelColorSync(j, (r,g,b));        
      }
    }
   
    // draw meteor
    for(int j = 0; j < meteorSize; j++) {
      if( ( i-j <numpixels) && (i-j>=0) ) {
        setPixelColorSync(i-j, (color));
      }
    }
   
    strip1.show();
    strip2.show();
    strip3.show();
    delay(SpeedDelay);
  }
}

void setStripSingleColor(Adafruit_NeoPixel strip, uint32_t color)
{
  strip.fill(color, 0, strip1.numPixels());
  strip.show();
}

void setPixelColorSync(int pixel, uint32_t color)
{
  strip1.setPixelColor(pixel, color);
  strip2.setPixelColor(pixel, color);
  strip3.setPixelColor(pixel, color);
}

void fillAllPixels(uint32_t color)
{
  strip1.fill(color, 0, strip1.numPixels());
  strip2.fill(color, 0, strip2.numPixels());
  strip3.fill(color, 0, strip3.numPixels());
}

String getValue(String data, char separator, int index)
{
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = data.length()-1;

  for(int i=0; i<=maxIndex && found<=index; i++){
    if(data.charAt(i)==separator || i==maxIndex){
        found++;
        strIndex[0] = strIndex[1]+1;
        strIndex[1] = (i == maxIndex) ? i+1 : i;
    }
  }

  return found>index ? data.substring(strIndex[0], strIndex[1]) : "";
}
