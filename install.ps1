Write-Host "Checking if pull request"
if ([bool]$env:APPVEYOR_PULL_REQUEST_NUMBER)
{
   Write-Host "Build is pull request - updating version"
   Update-AppveyorBuild -Version "0.0.0-pull-request-$($env:APPVEYOR_PULL_REQUEST_NUMBER)"
}

Write-Host "Checking if tag"
if ([bool]$env:APPVEYOR_REPO_TAG)
{
   Write-Host "Build is tag - updating version"
   Update-AppveyorBuild -Version $env:APPVEYOR_REPO_TAG_NAME
}
