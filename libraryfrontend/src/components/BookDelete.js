import '../scss/BookDelete.scss';
import { Button, Box, DialogTitle } from '@mui/material';

function BookDelete({ book, onDelete, onCloseModal }) {

    const handleClickDelete = () => {
        onDelete(book);
        onCloseModal();
    };

    return (
        <Box className="delete-book-dialog-contents">
            <DialogTitle>Are you sure you want to delete this book?</DialogTitle>
            <div className="delete-buttons-container">
                <Button className="cancel-delete-book-button" variant="contained" onClick={onCloseModal}>Cancel</Button>
                <Button className="delete-book-button" variant="outlined" onClick={handleClickDelete}>Delete</Button>
            </div>
        </Box>
    );
}

export default BookDelete;