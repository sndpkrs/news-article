<template>
    <div>
        <button @click="fetchData">Fetch Data </button>
        {{newsArticles}}
        <button @click="fetchDataUsingApi">Fetch Data from Api </button>
        {{newsArticles}}

        <br><br><br><br>
        {{errors}}
    </div>
</template>

<script>
import axios from 'axios'
export default {
    mounted: function() {
            axios
            .get('https://localhost:44394/api/newsarticle')
            .then(response => {
                this.newsArticles = response.data
            })
            .catch(error => {
                this.errors.push(error)
            })
    },
    data: function(){
        return {
            newsArticles: '',
            allErrors:[],
            errors: []  
        }
    },
    methods: {
        fetchData: function(){
            axios
            .get('https://api.myjson.com/bins/10ijyt')
            .then(response => {
                this.newsArticles = response.data
            })
            .catch(error => {
                this.errors.push(error)
            })
        },
        fetchDataUsingApi: function(){
            axios
            .post('https://localhost:44394/api/newsarticle',{})
            .then(response => {
                this.newsArticles = response.data
            })
            .catch(error => {
                this.errors.push(error)
            })
        }
    },
    components: {
        axios
    }
}
</script>