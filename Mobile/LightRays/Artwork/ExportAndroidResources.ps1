param (
    $inkscape_dir = "C:\Progra~1\Inkscape\bin\",
    $inkscape_bin = "inkscape.exe",
    $file = "Artwork.svg",
    $android_dir = "G:\LightRays\Mobile\LightRays\LightRays\Droid\Resources",
	$slice_layer_name = "SlicesAndroidResources"
)

$inkscape = resolve-path ("$inkscape_dir\$inkscape_bin")
$svgfile = resolve-path("$file")

[System.Xml.XmlDocument] $xdoc = new-object System.Xml.XmlDocument
$xdoc.load($svgfile)
write-host "Reading from file"
$groups = $xdoc.getElementsByTagName("g") # XPath is case sensitive
foreach ($group in $groups) {
	if($group.getAttribute("inkscape:groupmode") -eq "layer" ){
		if($group.getAttribute("inkscape:label") -eq "$slice_layer_name" ){
			# Warn if slices layer is visible
			if($group.getAttribute("style") -notcontains "display:none") {
				write-host -foreground yellow "Warning: Layer '$slice_layer_name' is still visible."
			}
			
			# Export each slice with its name
			foreach ($element in $group.getElementsByTagName('rect')) {
				$export_id = $element.getAttribute('id')
				$filename = "$export_id.png"
				$width = $element.getAttribute('width')
				$height = $element.getAttribute('height')
				write-host -NoNewLine "Exporting $filename "
				
				# Export to different densities for Android
				$cmd_mdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\drawable-mdpi\$filename --file=$svgfile --export-dpi=90 --export-background-opacity=0.0"
				$cmd_hdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\drawable-hdpi\$filename --file=$svgfile --export-dpi=135 --export-background-opacity=0.0"
				$cmd_xhdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\drawable-xhdpi\$filename --file=$svgfile --export-dpi=180 --export-background-opacity=0.0"
				$cmd_xxhdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\drawable-xxhdpi\$filename --file=$svgfile --export-dpi=270 --export-background-opacity=0.0"
				invoke-expression -command $cmd_mdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_hdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_xhdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_xxhdpi
				write-host -NoNewLine "."
				
				if ($? -eq $true) {
					write-host -foreground green " OK"
				} else {
					write-host -foreground red " FAIL"
				}
			}
		}
	}
}
#Write-Host "Press any key to continue ..."
#$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")