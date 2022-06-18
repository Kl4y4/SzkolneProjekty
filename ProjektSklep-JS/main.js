const express = require('express');
const { get } = require('express/lib/response');
const mysql = require('mysql');
const path = require('path');
const bodyParser = require('body-parser');
const indexRouter = require("./routes/index");
const orderRouter = require("./routes/order");


let app = express();
app.set('views', __dirname + '/view');
app.set('view engine', 'ejs');
app.use(express.static('public'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.use('/', indexRouter);
app.use('/product', orderRouter);

app.listen(3000);
