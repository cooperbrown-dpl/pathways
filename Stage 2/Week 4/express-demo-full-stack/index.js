const Joi = require('joi');
const express = require('express');
const app = express();

app.use(express.static('public'));

app.use(express.json());

const songs = [
    {
        id: 1,
        title: "In the End",
        artist: "Linkin Park",
        album: "Hybrid Theory",
        releaseYear: 2000,
        genre: "Nu-Metal",
        isExplicit: false
    },
    {
        id: 2,
        title: "Worldwide choppers",
        artist: "Tech N9ne",
        album: "All 6's and 7's",
        releaseYear: 2011,
        genre: "Hip-Hop",
        isExplicit: true
    },
    {
        id: 3,
        title: "Down",
        artist: "311",
        album: "The Blue Album",
        releaseYear: 1995,
        genre: "Alternative Rock",
        isExplicit: false
    }
];

app.get('/', (req, res) => {
    res.send('Hello Full Stack');
});

app.get('/api/songs', (req, res) => {
    res.send(songs);
});

app.get('/api/songs/:id', (req, res) => {
    const song = songs.find(s => s.id === parseInt(req.params.id));
    if (!song) return res.status(404).send('The song with the given ID was not found.');
    res.send(song);
});

// app.get('/api/songs/?isExplicit=true', (req, res) => {
//     const song = songs.find(s => s.isExplicit === (req.query.isExplicit === 'true'));
//     if (!song) return res.status(404).send('The explicit song was not found.');
//     res.send(song);
// });

app.post('/api/songs', (req, res) =>{
    const { error } = validateSong(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message);
    
    const song = {
        id: songs.length + 1,
        title: req.body.title,
        artist: req.body.artist,
        album: req.body.album,
        releaseYear: req.body.releaseYear,
        genre: req.body.genre,
        isExplicit: req.body.isExplicit
    };
    songs.push(song);
    res.send(song);
})

app.put('/api/songs/:id', (req, res) => {
    const song = songs.find(s => s.id === parseInt(req.params.id));
    if (!song) return res.status(404).send('The song with the given ID was not found.');

    const { error } = validateSong(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message);

    song.title = req.body.title;
    song.artist = req.body.artist;
    song.album = req.body.album;
    song.releaseYear = req.body.releaseYear;
    song.genre = req.body.genre;
    song.isExplicit = req.body.isExplicit;
    res.send(song);
})

app.delete('/api/songs/:id', (req, res) => {
    const song = songs.find(s => s.id === parseInt(req.params.id));
    if (!song) return res.status(404).send('The song with the given ID was not found.');

    const index = songs.indexOf(song);
    songs.splice(index, 1);

    res.send(song);
})

// PORT
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));


function validateSong(song) {
    const schema = {
        title: Joi.string().min(2).required(),
        artist: Joi.string().min(2).required(),
        album: Joi.string().min(2).required(),
        releaseYear: Joi.number().integer().min(1900).max(new Date().getFullYear()).required(),
        genre: Joi.string().min(2).required(),
        isExplicit: Joi.boolean().required()
    };

    return Joi.validate(song, schema);
}