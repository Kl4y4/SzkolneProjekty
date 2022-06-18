const express = require("express");
const router = express.Router();
const db = require("../db");


router.get('/', (req, res) => {
    let objs = [];

    let sql = `select idDecku, Nazwa, Cena, LinkZdjecie from decki where LSztuk > 0`;
    if (req.query.szerokosc != undefined && req.query.szerokosc != null) {
        sql += ` AND szerokosc = ${req.query.szerokosc}`;
    }

    if (req.query.inpMaxCena != undefined && req.query.inpMaxCena != null) {
        sql += ` AND cena <= ${req.query.inpMaxCena}`;
    }

    console.log(sql);

    db.query(sql, (err, result) => {
        if (err) throw err;

        if (result.length == undefined) {
            db.query(`select idDecku, Nazwa, Cena, LinkZdjecie from decki where LSztuk > 0;`, (err, result3) => {
                for (let i = 0; i < result3.length; i++) {
                    objs[i] = {
                        IdDecku: result3[i].idDecku,
                        Nazwa: result3[i].Nazwa,
                        Cena: result3[i].Cena,
                        LinkZdjecie: result3[i].LinkZdjecie
                    };
                }
                db.query(`select max(Cena) as 'maxCena' from decki where LSztuk > 0;`, (err, result2) => {
                    if (err) throw err;
                    res.render('index', { decks: objs, maxCena: Math.ceil(result2[0].maxCena) });
                });
            });
        }

        for (let i = 0; i < result.length; i++) {
            objs[i] = {
                IdDecku: result[i].idDecku,
                Nazwa: result[i].Nazwa,
                Cena: result[i].Cena,
                LinkZdjecie: result[i].LinkZdjecie
            };
        }
        db.query(`select max(Cena) as 'maxCena' from decki where LSztuk > 0;`, (err, result2) => {
            if (err) throw err;
            res.render('index', { decks: objs, maxCena: Math.ceil(result2[0].maxCena) });
        });
    });
});

router.get('/about', (req, res) => {
    res.render('about');
});

module.exports = router;
