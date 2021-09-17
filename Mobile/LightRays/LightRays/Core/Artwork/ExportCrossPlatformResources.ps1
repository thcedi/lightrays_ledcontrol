param (
    $inkscape_dir = "C:\Progra~1\Inkscape\",
    $inkscape_bin = "inkscape.exe",
    $file = "Artwork.svg",
    $android_dir = "C:\Users\CNagler.LACOSINTERN\Pictures\Saved Pictures\lightrays_ledcontrol\Mobile\LightRays\LightRays\Droid\Resources",
	$uwp_dir = "..\..\UWP",
	$ios_dir = "..\..\iOS\Resources",
	$slice_layer_name = "SlicesCrossPlatformResources"
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
				$cmd_mdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\mipmap-mdpi\$filename --file=$svgfile --export-dpi=90 --export-background-opacity=0.0"
				$cmd_hdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\mipmap-hdpi\$filename --file=$svgfile --export-dpi=135 --export-background-opacity=0.0"
				$cmd_xhdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\mipmap-xhdpi\$filename --file=$svgfile --export-dpi=180 --export-background-opacity=0.0"
				$cmd_xxhdpi = "$inkscape --export-id=$export_id --export-png=$android_dir\mipmap-xxhdpi\$filename --file=$svgfile --export-dpi=270 --export-background-opacity=0.0"
				invoke-expression -command $cmd_mdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_hdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_xhdpi
				write-host -NoNewLine "."
				invoke-expression -command $cmd_xxhdpi
				write-host -NoNewLine "."
				
				# Export to different densities for iOS
				$filename_1x = "$export_id.png"
				$cmd_small = "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename_1x --file=$svgfile --export-dpi=55 --export-background-opacity=0.0"
				$filename_2x = "$export_id@2x.png"
				$cmd_small2x = "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename_2x --file=$svgfile --export-dpi=109 --export-background-opacity=0.0"
				$filename_3x = "$export_id@3x.png"
				$cmd_small3x = "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename_3x --file=$svgfile --export-dpi=164 --export-background-opacity=0.0"
				invoke-expression -command $cmd_small
				write-host -NoNewLine "."
				invoke-expression -command $cmd_small2x
				write-host -NoNewLine "."
				invoke-expression -command $cmd_small3x
				write-host -NoNewLine "."
				
				# Export for UWP
				$cmd_uwp = "$inkscape --export-id=$export_id --export-png=$uwp_dir\$filename --file=$svgfile --export-dpi=180 --export-background-opacity=0.0"
				invoke-expression -command $cmd_uwp
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