import { useState } from 'react';
import { Box, DialogTitle } from '@mui/material';
import CreateEditForm from './CreateEditForm';

function BookCreate({ onCreate, onCloseModal }) {

    const [title, setTitle] = useState('');
    const [author, setAuthor] = useState('');
    const [description, setDescription] = useState('');
    const [year, setYear] = useState('');
    const [bookCoverFile, setBookCoverFile] = useState({});

    return (
        <Box className="create-edit-modal">
            <DialogTitle className="create-edit-modal-title">
                Add a book to the Troy Web Library collection
            </DialogTitle>
            <CreateEditForm
                book={null}
                title={title}
                setTitle={setTitle}
                author={author}
                setAuthor={setAuthor}
                description={description}
                setDescription={setDescription}
                year={year}
                setYear={setYear}
                bookCoverFile={bookCoverFile}
                setBookCoverFile={setBookCoverFile}
                onCreateEdit={onCreate}
                onCloseModal={onCloseModal}
            />
        </Box>
    );
}

export default BookCreate;