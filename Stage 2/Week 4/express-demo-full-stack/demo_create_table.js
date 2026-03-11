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
  let sql = `CREATE TABLE songs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    artist VARCHAR(255) NOT NULL,
    album VARCHAR(255),
    releaseYear INT,
    genre VARCHAR(100),
    isExplicit BOOLEAN DEFAULT FALSE
    )`;

  con.query(sql, function (err, result) {
    if (err) throw err;
    console.log("Table created");
  });
});