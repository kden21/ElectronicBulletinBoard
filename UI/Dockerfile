FROM node:alpine as builder
WORKDIR /app
COPY "UI/." "UI/"
WORKDIR "/app/UI"
RUN npm install -g @angular/cli@14.2.6
RUN npm install -g http-server
RUN npm install
CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "80", "--configuration", "production", "--disable-host-check"]