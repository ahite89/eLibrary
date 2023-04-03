import { Button, TextField } from '@mui/material';
import PhotoDropzone from './PhotoDropzone';

function CreateEditForm({ book, title, setTitle, author, setAuthor, description, setDescription,
                        year, setYear, bookCoverFile, setBookCoverFile, onCreateEdit, onCloseModal }) {

    const handleSubmit = (event) => {
        event.preventDefault();

        const newOrUpdatedbook = {
            Id: book == null ? null : book.id,
            Title: title,
            Author: author,
            Description: description,
            Year: year
        };

        onCreateEdit(newOrUpdatedbook, bookCoverFile);
        onCloseModal();

        // Clear fields if creating
        if (book == null) {
            setTitle('');
            setAuthor('');
            setDescription('');
            setYear('');
            setBookCoverFile({});
        }
    };

    return (
        <form className='create-edit-book-form' onSubmit={handleSubmit}>
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
                multiline
                rows={5}
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
            <Button variant="contained" type="submit">Add Book</Button>
        </form>
    );
}

export default CreateEditForm;