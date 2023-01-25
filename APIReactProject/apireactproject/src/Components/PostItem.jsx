import React from 'react';
import MyButton from './UI/button/MyButton';

const PostItem = (props) => {
    return (
        <div className="post">
            <div className="postContent">
                <strong>{props.post.id}. {props.post.title}</strong>
                <div>
                    {props.post.body}
                </div>
            </div>
            <div className="postButtons">
                <MyButton onClick={() => props.remove(props.post.id)}>Удалить</MyButton>
            </div>
        </div>  
    );
}

export default PostItem;