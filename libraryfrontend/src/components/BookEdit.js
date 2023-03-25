import { useState } from 'react';
import { Button, TextField } from '@mui/material';

function BookEdit({ book, onEdit, setEditToggle }) {

    const [newTitle, setNewTitle] = useState(book.title);
    const [newAuthor, setNewAuthor] = useState(book.author);
    const [newDescription, setNewDescription] = useState(book.description);
    const [newYear, setNewYear] = useState(book.year);

    const handleSubmit = (event) => {
        event.preventDefault();
        onEdit(book.id, newTitle, newAuthor, newDescription, newYear);
        setEditToggle(false);
    };

    return (
        <div className='edit-book-container'>
            <form className='edit-book-form' onSubmit={handleSubmit}>
                <TextField
                    required
                    variant="outlined"
                    value={newTitle}
                    onChange={(event) => setNewTitle(event.target.value)}
                />
                <TextField
                    required
                    variant="outlined"
                    value={newAuthor}
                    onChange={(event) => setNewAuthor(event.target.value)}
                />
                <TextField
                    required
                    variant="outlined"
                    rows={10}
                    value={newDescription}
                    onChange={(event) => setNewDescription(event.target.value)}
                />
                <TextField
                    required
                    variant="outlined"
                    value={newYear}
                    onChange={(event) => setNewYear(event.target.value)}
                />
                <Button variant="contained" type="submit">Save</Button>
            </form>
        </div>
    );
}

export default BookEdit;