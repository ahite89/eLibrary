import { useCallback } from 'react';
import { useDropzone } from 'react-dropzone';
import { Typography } from '@mui/material';

function PhotoDropzone({ setFile }) {
    const onDrop = useCallback(acceptedFiles => {
        setFile(acceptedFiles[0]);
    }, [])

    const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })

    return (
        <>
            <Typography>Upload Book Cover</Typography>
            <div {...getRootProps()}>
                <input {...getInputProps()} />
                {isDragActive ?
                    <Typography>Drop or upload here</Typography> :
                    <Typography>Good job</Typography>
                }
            </div>
        </>
    );
}

export default PhotoDropzone;