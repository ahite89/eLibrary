import '../scss/BookShow.scss';
import { useState } from 'react';
import { Button, Card, Typography } from '@mui/material';
import BookEdit from './BookEdit';

function BookShow({ book, onDelete, onEdit, onCheck, userRole }) {

    const [editMode, setEditMode] = useState(false);

    const handleEditToggle = () => {
        setEditMode(true);
    };

    const handleClickDelete = () => {
        onDelete(book);
    };

    const handleClickChangeCheckStatus = () => {
        onCheck(book);
    };

    const checkButtonDisabled = (book.checkedOut && userRole === 'user')
        || (!book.checkedOut && userRole === 'librarian');

    return (
        <Card className="book-show">
            <div className='book-contents-container'>
                <img className='book-cover'                   
                    src={book.bookCoverUrl} />
                {!editMode &&
                    <div className='book-contents'>
                        <div className="book-title-actions-container">
                            <Typography variant="h4" className='book-title'>{book.title}</Typography>
                            {userRole === "librarian" &&
                                <div className="book-actions">
                                    <i className="bi bi-pencil-square toggle-edit-icon" onClick={handleEditToggle}></i>
                                    <i className="bi bi-trash3 delete-icon" onClick={handleClickDelete}></i>
                                </div>
                            }
                        </div>
                        <Typography variant="h5" className="book-author">by {book.author}</Typography>
                        <Typography variant="h5" className="book-year">{book.year}</Typography>
                        <Typography variant="h5" className='book-description'>{book.description}</Typography>
                        <div className="check-status-container">
                            <Typography variant="h5" className="availability-text"
                                style={{ color: book.checkedOut ? "#7c0000" : "green" }}>
                                {book.checkedOut ? "Not Available" : "Available"}
                            </Typography>
                            <Button
                                disabled={checkButtonDisabled}
                                variant="contained"
                                className='check-status-toggle-button'
                                onClick={handleClickChangeCheckStatus}>
                                Check {userRole === 'user' ? 'out' : 'in'}
                            </Button>
                        </div>
                    </div>            
                }
                {editMode && userRole === "librarian" &&
                    <BookEdit book={book} onEdit={onEdit} setEditToggle={setEditMode} />
                }
            </div>
        </Card>
    );
}

export default BookShow;