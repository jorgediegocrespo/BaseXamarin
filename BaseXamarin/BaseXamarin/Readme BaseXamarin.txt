1. Remove "BaseXamarin" project on Android and iOS project and add a reference to comun project
2. Replace "BaseXamarin" by $porjectName$ on the whole solution.
3. Replace "basexamarin" by $porjectName$ on the whole solution.
4. Specify secretIOS and secretDROID on LogService.
	- Set secretIOS y secretDROID values on LogService class
5. Specify correct path for localize resource files.
	- Change ResourceId on TranslateExtension class
	- Change ResourceManager on AppResources.Designer.cs file
6. Specify api rest keys on ApiServiceKeys class
7. Remove assets catalog from iOS csproj
