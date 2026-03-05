const Joi = require('joi');
const express = require('express');
const app = express();

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
        album: "311",
        releaseYear: 1995,
        genre: "Alternative Rock",
        isExplicit: false
    }
];

app.get('/', (req, res) => {
    res.send('Hello Full Stack');
});

app.get('/api/courses', (req, res) => {
    res.send(songs);
});

app.get('/api/courses/:id', (req, res) => {
    const course = songs.find(c => c.id === parseInt(req.params.id));
    if (!course) return res.status(404).send('The course with the given ID was not found.');
    res.send(course);
});

app.post('/api/courses', (req, res) =>{
    const { error } = validateCourse(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message);
    
    const course = {
        id: songs.length + 1,
        name: req.body.name
    };
    songs.push(course);
    res.send(course);
})

app.put('/api/courses/:id', (req, res) => {
    const course = songs.find(c => c.id === parseInt(req.params.id));
    if (!course) return res.status(404).send('The course with the given ID was not found.');

    const { error } = validateCourse(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message);

    course.name = req.body.name;
    res.send(course);
})

app.delete('/api/courses/:id', (req, res) => {
    const course = songs.find(c => c.id === parseInt(req.params.id));
    if (!course) return res.status(404).send('The course with the given ID was not found.');

    const index = songs.indexOf(course);
    songs.splice(index, 1);

    res.send(course);
})

// PORT
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));


function validateCourse(course) {
    const schema = {
        name: Joi.string().min(3).required()
    };

    return Joi.validate(course, schema);
}