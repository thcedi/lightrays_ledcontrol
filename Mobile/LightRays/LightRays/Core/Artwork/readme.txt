The process is as follows:

    -First, draw your image as usual.
    -Then, add a layer that will hold the slices; name it slices (this is important). Move the layer to the background. 
     Enable the grid, and make sure it is set to pixels: you want your slices to align with pixel boundaries.
    -Draw your slice rectangles onto the slices layer, aligned to the grid. Ensure that the rectangles have 
     no border; the fill is irrelevant (I use gray).
    -Right-click a slice, and choose Object Properties. Change Id field to the name of the eventual PNG file, without 
     the extension. The area defined by	a rectangle named foo will be saved to foo.png. Repeat this for all slices.
    -Hide the slices layer. If you forget this, the script will print a warning.
    -Save your image. Let's say you called it Artwork.svg.
    -Modify the params section of the .ps1 script to match your projects and inkscape directories
    -Run the script ExportResources.ps1
    -You should see each of your slices being exported to a PNG file in the given directory.
