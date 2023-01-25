import React, { useState } from 'react'
import MyButton from './UI/button/MyButton';
import MyInput from './UI/input/MyInput';
import PostService from './../API/PostService';

const PostForm = ({create}) => {
  const [post,setPost] = useState({title:'',body:''})   

  const addNewPost = async (e) => {
      e.preventDefault();
      const response = await PostService.addNewPost(post.title, post.body);
      create(response);
      setPost({title:'',body:''})  
    }
  return (
    <form>
        <MyInput value={post.title} onChange={e => setPost({...post,title: e.target.value})} type="text" placeholder="Название поста"/>
        <MyInput value={post.body} onChange={e => setPost({...post,body: e.target.value})} type="text" placeholder="Описание поста"/>
        <MyButton onClick={addNewPost}>Создать пост</MyButton>
    </form>
  );
}

export default PostForm;