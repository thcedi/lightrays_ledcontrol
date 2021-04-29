#include <Adafruit_NeoPixel.h>

/* 
 *  Char - Effect Mappings:
 *  a   -   rainbow
 *  b   -   rainbow fade
 *  c   -   fire
 *  d   -   comet
 *  e   -   huewheel
 *  f   -   
 *  g   -   
 *  ...
 *  x   -   off
 */

Adafruit_NeoPixel strip1(20, 2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel strip2(20, 6, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel strip3(20, 12, NEO_GRB + NEO_KHZ800);

String strip1Effect = "";
String strip2Effect = "";
String strip3Effect = "";

void setup() 
{
  Serial.begin(9600);
  
  strip1.begin();           // INITIALIZE NeoPixel strip1 object (REQUIRED)
  strip2.begin();
  strip3.begin();
  
  strip1.show();            // Turn OFF all pixels ASAP
  strip2.show();
  strip3.show();
  
  strip1.setBrightness(255); // Set BRIGHTNESS to about 1/5 (max = 255)
  strip2.setBrightness(255);
  strip3.setBrightness(255);
}

void loop() 
{
  updateState();

  if(strip1Effect != "") handleStrip(1);
  if(strip2Effect != "") handleStrip(2);
  if(strip3Effect != "") handleStrip(3);

  strip1.show();
  strip2.show();
  strip3.show();
}

void handleStrip(int stripId)
{  
  char selectedEffect;
  bool singleColor;

  switch(stripId)
  {
    case 1:
      selectedEffect = strip1Effect[0];
      singleColor = strip1Effect.indexOf(',') != -1;
      if(singleColor)
      {    
         strip1.fill(strip1.Color(getValue(strip1Effect, ',', 0).toInt(), 
                                  getValue(strip1Effect, ',', 1).toInt(),
                                  getValue(strip1Effect, ',', 2).toInt()),
                                  0, strip1.numPixels()); 
         strip1.show();
      }
      else { updateEffect(1, selectedEffect); }
      break;   
      
    case 2:
      selectedEffect = strip2Effect[0];
      singleColor = strip2Effect.indexOf(',') != -1;
      if(singleColor)
      {    
         strip2.fill(strip2.Color(getValue(strip2Effect, ',', 0).toInt(), 
                                  getValue(strip2Effect, ',', 1).toInt(),
                                  getValue(strip2Effect, ',', 2).toInt()),
                                  0, strip2.numPixels()); 
         strip2.show();
      }
      else { updateEffect(2, selectedEffect); }
      break;
      
    case 3:
      selectedEffect = strip3Effect[0];
      singleColor = strip3Effect.indexOf(',') != -1;
      if(singleColor)
      {    
         strip3.fill(strip3.Color(getValue(strip3Effect, ',', 0).toInt(), 
                                  getValue(strip3Effect, ',', 1).toInt(),
                                  getValue(strip3Effect, ',', 2).toInt()),
                                  0, strip3.numPixels()); 
         strip3.show();
      }
      else { updateEffect(3, selectedEffect); }
      break;
  }
}

void updateEffect(int stripId, char effect)
{
    switch(effect)
    {
      case 'a':
        rainbow(stripId, 5, 25);
        break;
      case 'b':
        rainbow(stripId, 10, 100);
        break;
      case 'c':
        //fire(strip, 10,25,35);
        break;
      case 'd':
        //comet(strip, (0xff,0xff,0xff),10, 64, true, 30);
        break;
      case 'e':
        simpleColorChange();
        break;
      case 'x':
        // off
        break;
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
    String effect = getValue(input, ';', 1);

    if(stripId.toInt() == 0)
    {
      // Sync
      Serial.print("sync all strips with effect: "); Serial.println(effect);
      strip1Effect = effect;
      strip2Effect = effect;
      strip3Effect = effect;
    }
    else
    {
      // Single strip
      Serial.print("set strip "); Serial.print(stripId.toInt()); Serial.print(" effect to: "); Serial.println(effect);
      
      switch(stripId.toInt())
      {
        case 1:
          strip1Effect = effect;
          break;
        case 2:
          strip2Effect = effect;
          break;
        case 3:
          strip3Effect = effect;
          break;
      }
    }
  }
}

long rainbow_currentHue = 0;
void rainbow(int stripId, int wait, int effectWidth) 
{
  if(rainbow_currentHue < 5*65536)
  {
    for(int i=0; i<effectWidth; i++) 
    { 
      int pixelHue = rainbow_currentHue + (i * 65536L / effectWidth);
      switch(stripId)
      {
        case 1:
          strip1.setPixelColor(i, strip1.gamma32(strip1.ColorHSV(pixelHue)));
          break;  
        case 2:
          strip2.setPixelColor(i, strip2.gamma32(strip2.ColorHSV(pixelHue)));
          break;
        case 3:
          strip3.setPixelColor(i, strip3.gamma32(strip3.ColorHSV(pixelHue)));
          break;
      }
      
    }
    
    rainbow_currentHue += 256;
  }
  else
  {
    rainbow_currentHue = 0;
  }

  //delay(1);
}

int lastHueSimpleColorChange;
void simpleColorChange()
{
  if(lastHueSimpleColorChange >= 65536) lastHueSimpleColorChange = 0;

  fillAllPixels(strip1.ColorHSV(lastHueSimpleColorChange));
  lastHueSimpleColorChange += 5;
}

void fire(int Cooling, int Sparking, int SpeedDelay) 
{
  int NUM_LEDS = 20;
  static byte heat[20];
  int cooldown;
   
  // Step 1.  Cool down every cell a little
  for( int i = 0; i < NUM_LEDS; i++) {
    cooldown = random(0, ((Cooling * 10) / NUM_LEDS) + 2);
   
    if(cooldown>heat[i]) {
      heat[i]=0;
    } else {
      heat[i]=heat[i]-cooldown;
    }
  }
 
  // Step 2.  Heat from each cell drifts 'up' and diffuses a little
  for( int k= NUM_LEDS - 1; k >= 2; k--) {
    heat[k] = (heat[k - 1] + heat[k - 2] + heat[k - 2]) / 3;
  }
   
  // Step 3.  Randomly ignite new 'sparks' near the bottom
  if( random(255) < Sparking ) {
    int y = random(7);
    heat[y] = heat[y] + random(160,255);
    //heat[y] = random(160,255);
  }

  // Step 4.  Convert heat to LED colors
  for( int j = 0; j < NUM_LEDS; j++) {
    setPixelHeatColor(j, heat[j] );
  }

  strip1.show();
  strip2.show();
  strip3.show();
  delay(SpeedDelay);
}

void setPixelHeatColor (int Pixel, byte temperature) 
{
  // Scale 'heat' down from 0-255 to 0-191
  byte t192 = round((temperature/255.0)*191);
 
  // calculate ramp up from
  byte heatramp = t192 & 0x3F; // 0..63
  heatramp <<= 2; // scale up to 0..252
 
  // figure out which third of the spectrum we're in:
  if( t192 > 0x80) {                     // hottest
    setPixelColorSync(Pixel, strip1.Color(255, 255, heatramp));
  } else if( t192 > 0x40 ) {             // middle
    setPixelColorSync(Pixel, strip1.Color(255, heatramp, 0));
  } else {                               // coolest
    setPixelColorSync(Pixel, strip1.Color(heatramp, 0, 0));
  }
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

void setStripSingleColor(uint32_t color)
{
  strip1.fill(color, 0, strip1.numPixels());
  strip1.show();
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
