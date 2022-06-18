const mysql = require('mysql');

const connection = mysql.createConnection({
    host : 'localhost',
    user : 'root',
    password : '',
    database : 'skateshop'
});

connection.connect((err) => {
    if (err) throw err;
    console.log("Połączenie nawiazane z baza");
});

module.exports = connection;

