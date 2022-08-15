
# initialize Dapr
dapr init -k

# verify Dapr in AKS
kubectl get pods -n dapr-system -w
kubectl get services -n dapr-system -w
dapr dashboard -k