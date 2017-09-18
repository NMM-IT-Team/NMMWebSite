function loadmembers()
{

    // Defining the local dataset
    var members_list = ['Abhijit and Gauri Pimprikar', 'Amit and Padmaja Khot', 'Anand and Pooja Deshmukh', 'Anup and Mitali Bihani', 'Anurag Nayak and Garima Jain', 'Balwant Patil, Smita Biradar', 'Bhushan and Sneha Makade', 'Chhaya and Vijay Gayee', 'Deepak and Manjusha Pawar', 'Dinesh Bhirud', 'Ganesh and Roshni', 'Geeta Rajgor and Prashant Gaigavale', 'Geetanjali and Ajit Godbole', 'Gopal and Madhuri Jadhav', 'Hemant and Nikita Munot', 'Himanshu and Roopa Gadgil', 'Hiteshi Patel', 'Ishwar and Anuradha Ganure', 'Jay and Saraswathi Pawar', 'Jayanti gidde', 'Lalita and Atul Kunte', 'Madhavi and Gautam Bhadbhade', 'Manish Gupta and Sonam Dxit', 'Manoj and Priya Bhde', 'Mayur Patil and Archana Purushothaman', 'Milind Rahate', 'Nikhil and Asmita Warke', 'Nikhil and Geeta Ambekar ', 'Nitin and Nilam Patil', 'Pallavi Samant', 'Ravi Dixit', 'Sachin Birar', 'Saket Bapat', 'Sandeep and Suvrna Ghotikar', 'Sanjay and Chandrakala Jadhav', 'Sathish and Chhaya', 'Shailesh Khose and Swati', 'Shailesh Verma and Family', 'Sheetal and Rupali Munjewar', 'Shridhar and Shruti  Kulkarni', 'Shruti ', 'Sonam and Prakash Rathore', 'Subhash and Rajshree Paknikar', 'Subodh Nimkar', 'Sunil and Sapna Rathod', 'Swapnil and Prajakta Dharmik', 'Vaibhav and Shital Varade', 'Yogesh and Priyanka Sonwane'];
    
    // Constructing the suggestion engine
    var members_list = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.whitespace,
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        local: members_list
    });
    
    // Initializing the typeahead
    $('.typeahead').typeahead({
        hint: true,
        highlight: true, /* Enable substring highlighting */
        minLength: 4 /* Specify minimum characters required for showing result */
    },
    {
        name: 'members',
        source: members_list,
        templates: {
        empty: function(context){
                  $(".tt-dataset").text('No Results Found');
        }
    }
    })
}