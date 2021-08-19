param (
    $inkscape_dir = "C:\Progra~1\Inkscape\",
    $inkscape_bin = "inkscape.exe",
    $file = "Artwork.svg",
	$ios_dir = "..\MobileClient\BoniPS.iOS\Resources",
	$slice_layer_name = "SlicesIOSResources"
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
				$filename = "ic_launcher"
				$width = $element.getAttribute('width')
				$height = $element.getAttribute('height')
				write-host -NoNewLine "Exporting $filename "
				
				# Export to different sizes for iOS
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename.png --file=$svgfile --export-width=29 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename@2x.png --file=$svgfile --export-width=58 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename@3x.png --file=$svgfile --export-width=87 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				# width 20
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-20@1x.png --file=$svgfile --export-width=20 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-20@2x.png --file=$svgfile --export-width=40 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-20@3x.png --file=$svgfile --export-width=60 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				# width 40
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-40@1x.png --file=$svgfile --export-width=40 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-40@2x.png --file=$svgfile --export-width=80 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-40@3x.png --file=$svgfile --export-width=120 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				# width 60
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-60@1x.png --file=$svgfile --export-width=60 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-60@2x.png --file=$svgfile --export-width=120 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-60@3x.png --file=$svgfile --export-width=180 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				# width 76
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-76@1x.png --file=$svgfile --export-width=76 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-76@2x.png --file=$svgfile --export-width=152 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				# width 167, 512, 1024
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-167@2x.png --file=$svgfile --export-width=167 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-512@1x.png --file=$svgfile --export-width=512 --export-background-opacity=0.0"
				write-host -NoNewLine "."
				invoke-expression -command "$inkscape --export-id=$export_id --export-png=$ios_dir\$filename-1024@1x.png --file=$svgfile --export-width=1024 --export-background-opacity=0.0"
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