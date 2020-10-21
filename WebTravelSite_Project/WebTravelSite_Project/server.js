'use strict';
var http = require('http');
var port = process.env.PORT || 1337;
var url = require("url");
var fs = require("fs");
var server = http.createServer(function (req, res) {
    var path = url.parse(req.url).pathname;
    switch (path) {
        case '/':
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write('<!doctype html>\n<html lang="en">\n' +
                '\n<meta charset="utf-8">\n<title>Test Web Page</title>\n' +
                '\n\n<h1>Test</h1>\n' +
                '<div><p>Here We are <p></div>' +
                '\n\n');
            res.end();
            break;
        case '/Index.html':
            fs.readFile(__dirname + path, function (error, data) {
                if (error) {
                    res.writeHead(404);
                    res.write(error);
                    res.end();
                } else {
                    res.writeHead(200, { 'Content-Type': 'text/html' });
                    res.write(data);
                    res.end;
                }
            });
            break;
        default:
            res.writeHead(404);
            res.write("OOOPS -- This page does not exist");
            res.end();
            break;
    }
});
server.listen(port);