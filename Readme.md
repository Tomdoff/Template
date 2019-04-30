# Readme
## commands
### Categories
-   curl -d '{"name": "tinned"}' -H "Content-Type: application/json" -X POST https://localhost:5001/api/categories -k
-   curl -X GET https://localhost:5001/api/categories -k 
    -   curl uses the `-d` flag to denote data 
    -   `-H` allows you to add headers (such as content-type: application/json)
    -   `-X` allows you to specify the HTTP verb for the request
    -   `-k` allows you to ignore the SSL certificate (great for local host, not so good on live)
