import { useState } from 'react';
import { Button, Box, TextField, DialogTitle } from '@mui/material';
import PhotoDropzone from './PhotoDropzone';

function BookCreate({ onCreate, onCloseModal }) {

    const [title, setTitle] = useState('');
    const [author, setAuthor] = useState('');
    const [description, setDescription] = useState('');
    const [year, setYear] = useState('');
    const [bookCoverFile, setBookCoverFile] = useState({});

    const handleSubmit = (event) => {
        event.preventDefault();

        const book = {
            Title: title,
            Author: author,
            Description: description,
            Year: year
        };

        onCreate(book, bookCoverFile);

        onCloseModal();
        setTitle('');
        setAuthor('');
        setDescription('');
        setYear('');
    };

    return (
        <Box className="create-book-modal">
            <DialogTitle className="create-book-modal-title">
                Add a book to the Troy Web Library collection
            </DialogTitle>
            <form className='create-book-form' onSubmit={handleSubmit}>
                <TextField
                    required
                    label='Title'
                    variant="outlined"
                    value={title}
                    onChange={(event) => setTitle(event.target.value)}
                />
                <TextField
                    required
                    label='Author'
                    variant="outlined"
                    value={author}
                    onChange={(event) => setAuthor(event.target.value)}
                />
                <TextField
                    required
                    //multiline
                    rows={10}
                    label='Description'
                    variant="outlined"
                    value={description}
                    onChange={(event) => setDescription(event.target.value)}
                />
                <TextField
                    required
                    label="Year"
                    variant="outlined"
                    value={year}
                    onChange={(event) => setYear(event.target.value)}
                />
                <PhotoDropzone setFile={setBookCoverFile} />
                <Button variant="contained" type="submit">Add</Button>
            </form>
        </Box>
    );
}

export default BookCreate;