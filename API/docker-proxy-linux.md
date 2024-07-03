server {
    listen 80;
    server_name kibokohouse.com www.kibokohouse.com;
    return 301 https://$host$request_uri;
}

server {
    listen 443 ssl;
    server_name kibokohouse.com www.kibokohouse.com;

    ssl_certificate /etc/letsencrypt/live/kibokohouse.com/fullchain.pem;
    ssl_certificate_key /etc/letsencrypt/live/kibokohouse.com/privkey.pem;

    # Uncomment the following lines if you have a certificate chain file
    # ssl_trusted_certificate /path/to/your_domain.ca-bundle;
    # ssl_verify_client off;

    location / {
        proxy_pass http://172.19.0.4:80;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }

    error_log /var/log/nginx/docker-proxy-error.log;
    access_log /var/log/nginx/docker-proxy-access.log;
}

server {
    listen 80;
    server_name za.kibokohouse.com;
    location / {
        proxy_pass http://172.19.0.3:80;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }

    error_log /var/log/nginx/docker-proxy-error.log;
    access_log /var/log/nginx/docker-proxy-access.log;
}