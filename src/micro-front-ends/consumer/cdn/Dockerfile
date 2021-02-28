FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY ./static .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80