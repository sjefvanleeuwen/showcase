docker run -d -p 9997:5000 --restart=always --name registry registry:2

http://localhost:9997/v2/_catalog

kubectl create secret docker-registry docker-registry --docker-server=localhost:9997 --docker-username='local' --docker-password='none' --docker-email='none'