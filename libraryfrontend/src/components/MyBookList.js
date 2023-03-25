import MyBookShow from './MyBookShow';

function MyBookList({ books }) {

    const listOfMyBooks = books.map((book) => {
        return <MyBookShow
            key={book.id}
            book={book}
        />
    });

    return (
        <>
            <div className='my-book-list'>
                {listOfMyBooks}
            </div>
        </>
    );
}

export default MyBookList;