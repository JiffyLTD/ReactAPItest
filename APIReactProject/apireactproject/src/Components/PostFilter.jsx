import React from 'react'
import MySelect from './UI/select/MySelect'
import MyInput from './UI/input/MyInput'

const PostFilter = ({filter, setFilter}) => {
  return (
    <div className="filter">
        <MyInput style={{width: '25%', fontSize: '18px'}} placeholder='Поиск...' value={filter.query}
                 onChange={e => setFilter({...filter, query: e.target.value})}/>
        <MySelect defaultValue="Сортировка"
                    value={filter.sort} onChange={selectedSort => setFilter({...filter, sort: selectedSort})}
                    option={[{value: 'title', name: 'По названию'},
                    {value: 'body', name: 'По описанию'}]}/>
    </div>
  )
}

export default PostFilter