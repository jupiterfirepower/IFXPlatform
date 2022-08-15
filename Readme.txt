# Install Windows Terminal Preview(for Windows 10)
https://docs.microsoft.com/en-us/windows/terminal/install

# Install Docker
https://docs.docker.com/desktop/install/windows-install/

https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe

# Install WSL 2 
https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi
# Power shell command (in Windows Terminal)
wsl --set-default-version 2

# Install Dapr CLI
powershell -Command "iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex"

# Install chocolatey
https://chocolatey.org/install

# Power shell command (in Windows Terminal)
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# Install Kubernetes in Docker

choco install minikube -y
minikube start --driver=docker
#--driver=hyperv
#--driver=docker
#--driver=virtualbox

[Environment]::SetEnvironmentVariable("KUBECONFIG", $HOME + "\.kube\config", [EnvironmentVariableTarget]::Machine)

# initialize Dapr
dapr init

# run command from Deploy manually or run powershell script

# run localy tenant microservice 
dapr run --app-id "tenant-microservice" --app-port "5000" --dapr-http-port "5010" -- dotnet run --project ./IX.Platform.Microservice.Tenant/IX.Platform.Microservice.Tenant.fsproj --urls="http://+:5000"
# run localy admin microservice
dapr run --app-id "admin-micro" --app-port "5000" --dapr-http-port "5011" -- dotnet run --project ./IX.Platform.Gateways.Admin/IX.Platform.Gateways.Admin.fsproj --urls="http://+:4000"