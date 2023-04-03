import { useState } from 'react';
import { Box, DialogTitle } from '@mui/material';
import CreateEditForm from './CreateEditForm';

function BookEdit({ book, onEdit, onCloseModal }) {

    const [newTitle, setNewTitle] = useState(book.title);
    const [newAuthor, setNewAuthor] = useState(book.author);
    const [newDescription, setNewDescription] = useState(book.description);
    const [newYear, setNewYear] = useState(book.year);
    const [bookCoverFile, setBookCoverFile] = useState({});

    return (
        <Box className="create-edit-modal">
            <DialogTitle className="create-edit-modal-title">
                Edit Book
            </DialogTitle>
            <CreateEditForm
                book={book}
                title={newTitle}
                setTitle={setNewTitle}
                author={newAuthor}
                setAuthor={setNewAuthor}
                description={newDescription}
                setDescription={setNewDescription}
                year={newYear}
                setYear={setNewYear}
                bookCoverFile={bookCoverFile}
                setBookCoverFile={setBookCoverFile}
                onCreateEdit={onEdit}
                onCloseModal={onCloseModal}
            />
        </Box>
    );
}

export default BookEdit;