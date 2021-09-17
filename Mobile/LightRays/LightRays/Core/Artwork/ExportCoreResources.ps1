param (
    $inkscape_dir = "C:\Progra~1\Inkscape\",
    $inkscape_bin = "inkscape.exe",
    $file = "Artwork.svg",
	$core_images_dir = "..\MobileClient\BoniPS.Core\Images",
	$slice_layer_name = "SlicesCoreResources"
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
				
				# Export to default density for the core
				$cmd = "$inkscape --export-id=$export_id --export-png=$core_images_dir\$filename --file=$svgfile --export-dpi=96 --export-background-opacity=0.0"
				invoke-expression -command $cmd
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