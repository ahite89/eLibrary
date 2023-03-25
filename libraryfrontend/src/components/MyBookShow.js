import '../scss/MyBookShow.scss';
import { Card, Typography } from '@mui/material';

function MyBookShow({ book }) {   

    return (
        <Card className="my-book-show">
            <div className="my-book-contents">
                <img className="my-book-cover" src={book.bookImageSrc} />
                <div className="my-book-info">
                    <Typography variant="h6" className="my-book-title">{book.title}</Typography>
                    <Typography variant="h6" className="my-book-author">{book.author}</Typography>
                </div>
            </div>
        </Card>
    );
}

export default MyBookShow;