<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>2474afc5-cfb2-4c63-aa91-12c4087819d9</Uid>
  <Name>EmailMessageParticipant</Name>
  <DisplayName>Участник письма</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <AllowCreateHeirs>true</AllowCreateHeirs>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>5dd6c791-037e-44f7-8e89-6d679be1fdf0</Uid>
      <Name>Uid</Name>
      <DisplayName>Уникальный идентификатор</DisplayName>
      <TypeUid>eb6e8ddc-fafe-4e0e-9018-1a7667012579</TypeUid>
      <Settings xsi:type="GuidSettings">
        <FieldName>Uid</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <IsSystem>true</IsSystem>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>57cd9014-871c-47f0-b1f5-4600fa36fd12</Uid>
      <Name>Name</Name>
      <DisplayName>Наименование</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>Name</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <Required>true</Required>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>1</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>15f523ba-7a38-458a-a4bf-ecad277f09d1</Uid>
      <Name>EmailString</Name>
      <DisplayName>Email</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>EmailString</FieldName>
        <MaxValue>320</MaxValue>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>2</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
  </Properties>
  <TableViews>
    <TableView>
      <Uid>7cddebaa-37b0-48a0-b36f-d72e36b4042a</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <TitlePropertyUid>57cd9014-871c-47f0-b1f5-4600fa36fd12</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>557cb1c9-4b4d-4be0-b3c8-c7d071e2931c</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>EmailMessageParticipant</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <Filterable>true</Filterable>
  <Filter />
  <Actions />
</Entity>