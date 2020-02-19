# Using the playground

## Local
In order to run it on local computer (with Docker for Windows already installed).

All in one
```
docker run -d --name jaeger \
			-e COLLECTOR_ZIPKIN_HTTP_PORT=9411 \
			-p 5775:5775/udp \
			-p 6831:6831/udp \
			-p 6832:6832/udp \
			-p 5778:5778 \
			-p 16686:16686 \
			-p 14268:14268 \
			-p 9411:9411 \
			jaegertracing/all-in-one
```

Browse to dashboard:

```
http://localhost:16686/search
```