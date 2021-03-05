FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM node:15 AS build
WORKDIR /usr/src/app
COPY . .
RUN npm ci
RUN npm run-script dist:build 

FROM base AS final
COPY --from=build ./usr/src/app/dist .
COPY nginx.conf /etc/nginx/nginx.conf
