<?php

class Database
{
    public $connection;

    public function __construct()
    {
        $this->connection = new PDO('mysql:host=tomat.trickip.net;dbname=simhopp', 'root', 'gallian0');
    }

    public function getData($query)
    {
        $result = ($this->connection)->query($query);

        return $result->fetchAll(PDO::FETCH_ASSOC);
    }
}