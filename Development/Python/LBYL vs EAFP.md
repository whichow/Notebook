<div>

    LBYL (Look Before You Leap):EAFP (it's Easier to Ask Forgiveness than Permission):
    EAFP方式更消耗性能EAFP更加优雅，可读性更好，LBYL更方便控制流程EAFP:try :
        a.doSomething()

    except Exception :

    LBYL:

    if a

        if b

            if c
                a.getB().getC().doSomething()

            else

        else

    else

</div>

<div>

\

</div>

<div>

LBYL方式需要访问dictionary两次

</div>

<div>

EAFP:

    try:
        x = my_dict["key"]except KeyError:# handle missing key

LBYL:

    if "key" in my_dict:
        x = my_dict["key"]else:# handle missing key

    EAFP在多线程下是原子的，更加安全

</div>

``
