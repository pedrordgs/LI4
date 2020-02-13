#!/bin/bash

FICH=tarefas.txt
TEMP=tarefas_temp

echo "1 - Adicionar tarefa."
echo "2 - Marcar tarefa como feita."

read _op

if [ $_op == 1 ]
then
    echo "Qual é a tarefa?"
    read tarefa
    echo $tarefa >> $FICH
    echo "Tarefa adicionada"
elif [ $_op == 2 ]
then
    tot=$(wc -l < $FICH)
    cat -n $FICH
    echo "Qual é a tarefa que que marcar como feita?"
    read lin
    head -n $((lin -1)) $FICH >> $TEMP
    l=$(sed -n "$lin"'p' < $FICH)
    echo "$l [DONE]" >> $TEMP
    tail -n $((tot - lin)) $FICH >> $TEMP
    mv $TEMP $FICH
else
    echo "Opção inválida!"
fi
