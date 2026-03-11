let mysql = require('mysql2');

let con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Password1",
  database: "mydb"
});

con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");
  let sql = "INSERT INTO songs (title, artist, album, releaseYear, genre, isExplicit) VALUES ('In the End', 'Linkin Park', 'Hybrid Theory', 2000, 'Nu-Metal', false)";
  con.query(sql, function (err, result) {
    if (err) throw err;
    console.log("1 record inserted");
  });
});