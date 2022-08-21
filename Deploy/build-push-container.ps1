# meant to be launched from the solution root folder
# with this file you can build all the project docker images with version and default$default
# in addition it pushes the images to the container registry
param (
    [string]$registry = "registry", 
    [string]$default = "latest"
    )
$builddate = "2022-08-21"
$buildversion = "2.0"

$container = "ifx.platform.microservice.tenant"
$latest = "{0}/{1}:{2}" -f $registry, $container, $default 
$versioned = "{0}/{1}:{2}" -f $registry, $container, $buildversion
docker build . -f .\src\Services\Core\Tenant\IX.Platform.Microservice.Tenant\Dockerfile -t $latest -t $versioned --build-arg BUILD_DATE=$builddate --build-arg BUILD_VERSION=$buildversion
docker push $versioned
docker push $latest 

$container = "ifx.platform.gateways.admin"
$latest = "{0}/{1}:{2}" -f $registry, $container, $default 
$versioned = "{0}/{1}:{2}" -f $registry, $container, $buildversion
docker build . -f .\src\Gateways\IX.Platform.Gateways.Admin\Dockerfile -t $latest -t $versioned --build-arg BUILD_DATE=$builddate --build-arg BUILD_VERSION=$buildversion
docker push $versioned
docker push $latest