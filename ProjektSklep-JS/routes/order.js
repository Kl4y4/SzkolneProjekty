const express = require("express");
const router = express.Router();
const db = require("../db");


router.get('/', (req, res) => {
    db.query(`select decki.idDecku, drewna.Nazwa as 'NazwaDrewna', decki.Nazwa, decki.Marka, decki.Szerokosc, decki.Cena, decki.LSztuk, decki.LinkZdjecie from decki inner join drewna on decki.idDrewna = drewna.idDrewna where decki.idDecku = ${req.query.id};`, (err, result) => {
        let deckInfo = {
            Id: req.query.id,
            Drewno: result[0].NazwaDrewna,
            Nazwa: result[0].Nazwa,
            Marka: result[0].Marka,
            Szerokosc: result[0].Szerokosc,
            Cena: result[0].Cena,
            LSztuk: result[0].LSztuk,
            LinkZdjecie: result[0].LinkZdjecie
        };
        res.render('product', { deckInfo });
    });
});

router.get('/order', (req, res) => {
    db.query(`select idDecku, Nazwa, LinkZdjecie from decki where idDecku = ${req.query.id};`, (err, result) => {
        if (err) throw err;
        res.render('order', { IdDecku: result[0].idDecku, LinkZdjecie: result[0].LinkZdjecie, Nazwa: result[0].Nazwa });
    });
});

router.post('/done', (req, res) => {

    console.log(req.body.imie);
    let sqlInsert = `INSERT INTO klienci(Imie, Nazwisko, Email, Miasto, Ulica, KodPoczt) VALUES ('${req.body.imie}', '${req.body.nazwisko}', '${req.body.email}', '${req.body.miasto}', '${req.body.ulica}', '${req.body.kodPoczt}');`

    db.query(sqlInsert, (err, result1) => {
        if (err) throw err;
        console.log(result1);
        db.query(`select max(idKlienta) as 'idKlienta' from klienci;`, (err, result2) => {
            if (err) throw err;
            console.log(result2);
            db.query(`INSERT INTO zamowienia(idDecku, idKlienta) VALUES ('${req.body.idDecku}', '${result2[0].idKlienta}');`, (err, result3) => {
                if (err) throw err;
                console.log(result3);
                db.query(`UPDATE decki SET LSztuk = LSztuk - 1 WHERE idDecku = ${req.body.idDecku};`, (err, result4) => {
                    if (err) throw err;
                    console.log(result4);
                    res.send('<p> Pomyślnie zamówiono produkt!<br /><a href="http://localhost:3000/"> Powrót do strony głównej </a> </p>');
                }) 
            })
        });
    });
});

module.exports = router;
