'use strict';
const http = require('http');
const port = process.env.PORT || 1337;
const url = require("url");
const fs = require("fs");
let server = http.createServer(function (req, res) {
    let path = url.parse(req.url).pathname;
    if (req.url.indexOf('.html') != -1) {
        fs.readFile(__dirname + '/' + path, function (error, data) {
            if (error) {
                res.writeHead(404);
                res.write(error);
                res.end();
            } else {
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.write(data);
                res.end();
            }
        });
    }
    if (req.url.indexOf('.css') != -1) {
        fs.readFile(__dirname + '/HomeStyle.css', function (error, data) {
            if (error) {
                res.writeHead(404);
                res.write(error);
                res.end();
            } else {
                res.writeHead(200, { 'Content-Type': 'text/css' });
                res.write(data);
                res.end();
            }
        });
    }
    if (req.url.indexOf('.js') != -1) {
        fs.readFile(__dirname + '/HomeTestScript.js', function (error, data) {
            if (error) {
                res.writeHead(404);
                res.write(error);
                res.end();
            } else {
                res.writeHead(200, { 'Content-Type': 'text/javascript' });
                res.write(data);
                res.end();
            }
        });
    }
 
});
server.listen(port);