# Diploma
 
## Оформление коммитов

### Префиксы

- **BF** - (bug fix) исправление бага
- **RF** - (refactoring) структурные изменения, затрагивающие 2 класса и более
- **NF** - (new feature) новая функциональность
- **CF** - (change feature) изменения логики существующей функциональности
- **OPT** - (optimization) различные локальные оптимизации
- **BK** - (breaks something) используется для колечащих изменений в api
- **TF** - (tests feature) используется только если изменения затрагивают только тесты. если изменения вносятся вместе с рефакторингом или новой фичей, то используются эти типы
- **DOC** - (documentation) изменения документация
- **DB-CH** - (database change) коммит требует изменений в базе данных

### Сообщение коммита

`[CHANGE_TYPE] short descriptive message in English`<br>
**Пример:**<br>
`[NF] add get profile command`