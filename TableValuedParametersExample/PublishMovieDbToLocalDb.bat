﻿"%ProgramFiles%\Microsoft SQL Server\130\Tools\Binn\SqlLocalDB.exe" create "ProjectsV13" 13.0 -s
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\130\SqlPackage.exe" /Action:Publish /SourceFile:"..\..\..\MovieDb\bin\Debug\MovieDb.dacpac" /Profile:"..\..\..\MovieDb\MovieDbPublishToLocalDb.publish.xml"
