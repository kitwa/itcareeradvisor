# Client 
ng build
# API
dotnet build
docker build -t dominichdocker/kibokohouse .
docker push dominichdocker/kibokohouse:latest

# SERVER

docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' kibokohouse
docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' zakibokohouse

cd /etc/nginx/sites-available
nano docker-proxy

sudo systemctl restart nginx

create docker-compose.yml file
docker image prune -af
docker-compose pull
docker-compose up --force-recreate --build -d

docker container prune