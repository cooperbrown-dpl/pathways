let mysql = require('mysql2');

let con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "Password1",
  database: "mydb" // Make sure this database exists!
});

con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");

  let sql = "INSERT INTO songs (title, artist, album, releaseYear, genre, isExplicit) VALUES ?";

  let values = [
    ['In the End', 'Linkin Park', 'Hybrid Theory', 2000, 'Nu-Metal', false],
    ['Numb', 'Linkin Park', 'Meteora', 2003, 'Nu-Metal', false],
    ['Bohemian Rhapsody', 'Queen', 'A Night at the Opera', 1975, 'Rock', false],
    ['Lose Yourself', 'Eminem', '8 Mile', 2002, 'Hip-Hop', true]
  ];

  con.query(sql, [values], function (err, result) {
    if (err) throw err;
    console.log("Number of records inserted: " + result.affectedRows);
  });
});