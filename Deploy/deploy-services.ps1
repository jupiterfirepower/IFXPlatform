$namespace = "default"

# deploy service of applications ONLY if using classic NGINX --- NOT NEEDED if using NGINX + Dapr
kubectl apply -f .\Deploy\ifx.platform.microservice.tenant.yaml --namespace $namespace
kubectl apply -f .\Deploy\ifx.platform.gateways.admin.yaml --namespace $namespace