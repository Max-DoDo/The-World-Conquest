using System;
using System.Collections;
using UnityEngine;

public class Client : MonoBehaviour
{   
    public delegate void CountrySelectionHandler(object sender, CountrySelectedEventArgs args);

    private Player player;

    private Country selectingCountry;

    private Country selectOnOri;

    public Client(){
        player = new Player(this);

    }

    public Country getSelectOnOri(){
        // 创建一个信号量来暂停执行
        bool waitForSelection = true;

        // 国家选择事件处理方法
        void HandleCountrySelection(object sender, CountrySelectedEventArgs args)
        {
            // 获取选择的国家对象
            Country selectedCountry = args.selectedCountry;

            // 设置返回值为选择的国家对象
            selectedCountryObject = selectedCountry;

            // 取消暂停执行
            waitForSelection = false;
        }

        // 订阅国家选择事件
        OnCountrySelected += HandleCountrySelection;

        // 等待用户选择国家
        while (waitForSelection)
        {
            // 暂停执行，等待用户选择
            // 这里可以用协程或者其他方式来避免阻塞主线程
            // 例如 yield return StartCoroutine(WaitForCountrySelection());
        }

        // 取消订阅国家选择事件
        OnCountrySelected -= HandleCountrySelection;

        // 返回用户选择的国家对象
        return selectedCountryObject;
    }

    void Update(){

    }


    private void joinGame(){

    }


    public void SelectCountry(Country country){

        if(selectingCountry != null){
            selectingCountry.isSelected = false;
        }
        selectingCountry = country;
        selectingCountry.isSelected = true;

        Debug.Log("Select: " + country);
        
    }


}
