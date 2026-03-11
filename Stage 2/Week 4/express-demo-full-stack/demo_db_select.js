let mysql = require('mysql2');

let con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Password1",
  database: "mydb" // Make sure this database exists!
});

con.connect(function(err) {
  if (err) throw err;
  con.query("SELECT * FROM songs", function (err, result, fields) {
    if (err) throw err;
    console.log(result);
  });
});