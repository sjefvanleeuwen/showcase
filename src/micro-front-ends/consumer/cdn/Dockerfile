FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM node:15 AS build
WORKDIR /usr/src/app
COPY . .

FROM base AS final
COPY --from=build ./usr/src/app/static .
COPY nginx.conf /etc/nginx/nginx.conf
