<?php

require '../vendor/autoload.php';
require '../src/config/db.php';

$app = new \Slim\App;

require '../src/routes/NMMEvents.php';

$app->run();
