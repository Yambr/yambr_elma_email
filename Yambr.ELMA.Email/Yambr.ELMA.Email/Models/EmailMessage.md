﻿<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>79626ca2-5121-485b-85c3-c4eb017726f8</Uid>
  <Name>EmailMessage</Name>
  <DisplayName>Электронное письмо</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <AllowCreateHeirs>true</AllowCreateHeirs>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>3b180cda-c266-4252-a43a-2d5093cf80d4</Uid>
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
      <Uid>58513e49-d049-4c88-b0e5-62adacb6876b</Uid>
      <Name>DateUtc</Name>
      <DisplayName>Дата письма</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>DateUtc</FieldName>
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
      <Order>1</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>d80dee87-7099-4baa-8490-852c4ebbd939</Uid>
      <Name>Hash</Name>
      <DisplayName>Hash</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>Hash</FieldName>
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
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>63ffa1a8-e8b0-47c7-8e2f-532a4b72a291</Uid>
      <Name>MainHeader</Name>
      <DisplayName>Основной заголовок</DisplayName>
      <TypeUid>0aef74a9-d37c-4731-813b-d5f0b5ec4392</TypeUid>
      <Settings xsi:type="HtmlStringSettings">
        <FieldName>MainHeader</FieldName>
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
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>3</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f2cfb4df-fb46-4a2b-aa20-3165cc08af79</Uid>
      <Name>Body</Name>
      <DisplayName>Тело письма</DisplayName>
      <TypeUid>0aef74a9-d37c-4731-813b-d5f0b5ec4392</TypeUid>
      <Settings xsi:type="HtmlStringSettings">
        <FieldName>Body</FieldName>
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
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>4</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>4b378993-25ae-457b-b8bb-3762cf7997a9</Uid>
      <Name>IsBodyHtml</Name>
      <DisplayName>Html письмо</DisplayName>
      <TypeUid>9cd56a40-6192-4d8a-840c-c4bd4dfb88eb</TypeUid>
      <Settings xsi:type="BoolSettings">
        <FieldName>IsBodyHtml</FieldName>
      </Settings>
      <Nullable>false</Nullable>
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
      <Order>5</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>a68aa038-1344-43fb-863f-6966eea402c1</Uid>
      <Name>Direction</Name>
      <DisplayName>Направление письма</DisplayName>
      <TypeUid>849c1ac9-4d46-4194-8cbb-43f84adf9c17</TypeUid>
      <SubTypeUid>efab67bf-2e70-4118-afb6-82d1990c3777</SubTypeUid>
      <Settings xsi:type="EnumSettings">
        <FieldName>Direction</FieldName>
        <DefaultValue>2c402344-245d-40f1-b6ad-95839adc8ed6</DefaultValue>
      </Settings>
      <Nullable>false</Nullable>
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
      <Order>6</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>6bb71d88-ab64-4fe3-813b-d7cae7677827</Uid>
      <Name>From</Name>
      <DisplayName>От</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>2474afc5-cfb2-4c63-aa91-12c4087819d9</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>ManyToMany</RelationType>
        <RelationTableName>M_EmailMessage_From</RelationTableName>
        <ParentColumnName>Parent</ParentColumnName>
        <ChildColumnName>Child</ChildColumnName>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Order>7</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>813fc69c-8716-40af-846c-4437552f50b5</Uid>
      <Name>To</Name>
      <DisplayName>Кому</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>2474afc5-cfb2-4c63-aa91-12c4087819d9</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>ManyToMany</RelationType>
        <RelationTableName>M_EmailMessage_To</RelationTableName>
        <ParentColumnName>Parent</ParentColumnName>
        <ChildColumnName>Child</ChildColumnName>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Order>8</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>eeeb8ddd-eb36-4903-ad28-2f467dffd44e</Uid>
      <Name>Subject</Name>
      <DisplayName>Тема</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>Subject</FieldName>
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
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>9</Order>
      <InFastSearch>true</InFastSearch>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>7c753539-013d-4137-8edb-78984be9012a</Uid>
      <Name>SubjectWithoutTags</Name>
      <DisplayName>Тема (без тегов)</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>SubjectWithoutTags</FieldName>
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
      <Order>10</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>fde76d12-ce30-4a72-8cd5-9bb85ba2dded</Uid>
      <Name>Tags</Name>
      <DisplayName>Теги</DisplayName>
      <Description>теги через запятую</Description>
      <TypeUid>317e3d72-9c47-4b68-926d-ba77a2579bc2</TypeUid>
      <Settings xsi:type="TextSettings">
        <FieldName>Tags</FieldName>
        <MultiLine>true</MultiLine>
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
      <Order>11</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>71fc1c0c-d424-4fbc-aa0c-0edff6352ce1</Uid>
      <Name>Owners</Name>
      <DisplayName>Владельцы письма</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>06aeb963-e379-4fff-9951-de6bf6cb508f</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>ManyToMany</RelationType>
        <RelationTableName>M_EmailMessage_Owners</RelationTableName>
        <ParentColumnName>Parent</ParentColumnName>
        <ChildColumnName>Child</ChildColumnName>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Order>12</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f4e9a5e6-7a5a-4682-af9f-9fd5df22ecdc</Uid>
      <Name>IsDeleted</Name>
      <DisplayName>IsDeleted</DisplayName>
      <TypeUid>9cd56a40-6192-4d8a-840c-c4bd4dfb88eb</TypeUid>
      <Settings xsi:type="BoolSettings">
        <FieldName>IsDeleted</FieldName>
      </Settings>
      <Nullable>false</Nullable>
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
      <Order>13</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f303976b-d9e1-43d3-b945-6f91e09ed452</Uid>
      <Name>Contacts</Name>
      <DisplayName>Контакты</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>a9b1bc6a-3286-4264-81aa-02f6df73c080</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>ManyToMany</RelationType>
        <RelationTableName>M_EmailMessage_Contacts</RelationTableName>
        <ParentColumnName>Parent</ParentColumnName>
        <ChildColumnName>Child</ChildColumnName>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Order>14</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>c5e79fc2-303d-4146-935f-12ddfd906d1e</Uid>
      <Name>Contractors</Name>
      <DisplayName>Контрагенты</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>38096146-0c73-4809-94f5-e18b2d525531</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>ManyToMany</RelationType>
        <RelationTableName>M_EmailMessage_Contractors</RelationTableName>
        <ParentColumnName>Parent</ParentColumnName>
        <ChildColumnName>Child</ChildColumnName>
        <CascadeMode>SaveUpdate</CascadeMode>
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
      <Order>15</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>bedd41f3-f821-45be-9ce1-aecfee0102d6</Uid>
      <Name>Text</Name>
      <DisplayName>Текст</DisplayName>
      <TypeUid>317e3d72-9c47-4b68-926d-ba77a2579bc2</TypeUid>
      <Settings xsi:type="TextSettings">
        <FieldName>Text</FieldName>
        <MultiLine>true</MultiLine>
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
      <Order>16</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
    </PropertyMetadata>
  </Properties>
  <FormsScheme>FormConstructor</FormsScheme>
  <DefaultForms>
    <CreateUid>574d8ce1-42d1-4fd7-9741-78ffcbeaa440</CreateUid>
    <EditUid>574d8ce1-42d1-4fd7-9741-78ffcbeaa440</EditUid>
    <DisplayUid>574d8ce1-42d1-4fd7-9741-78ffcbeaa440</DisplayUid>
  </DefaultForms>
  <Forms>
    <FormViewItem>
      <Name>Form</Name>
      <Uid>574d8ce1-42d1-4fd7-9741-78ffcbeaa440</Uid>
      <Items>
        <RootViewItem xsi:type="ColumnsLayoutViewItem">
          <Name>ColumnsLayout1</Name>
          <Uid>3b216296-0e7e-42cc-aa0a-42fef5fdab8c</Uid>
          <Items>
            <RootViewItem xsi:type="ColumnViewItem">
              <Name>Column1</Name>
              <Uid>b835c1a4-e908-4506-958c-6f8b5a3f2bcc</Uid>
              <Items>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property1</Name>
                  <Uid>2aa29de1-21c1-4552-ba35-0f3cfd89b40c</Uid>
                  <Property>6bb71d88-ab64-4fe3-813b-d7cae7677827</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property2</Name>
                  <Uid>65be8da8-502a-4f1e-8b5e-e4be440e408c</Uid>
                  <Property>813fc69c-8716-40af-846c-4437552f50b5</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property3</Name>
                  <Uid>65ea5768-1807-49a6-970b-95edb10b2d7e</Uid>
                  <Property>eeeb8ddd-eb36-4903-ad28-2f467dffd44e</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property4</Name>
                  <Uid>531b6d8a-3883-4977-b16b-40ac7b723059</Uid>
                  <Property>f2cfb4df-fb46-4a2b-aa20-3165cc08af79</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property5</Name>
                  <Uid>f1020472-42e0-4595-8ff7-6fcedca67d29</Uid>
                  <Property>a68aa038-1344-43fb-863f-6966eea402c1</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property6</Name>
                  <Uid>bf6a8e60-b425-48a5-8e5e-79c2cf608143</Uid>
                  <Property>71fc1c0c-d424-4fbc-aa0c-0edff6352ce1</Property>
                  <Attributes />
                </RootViewItem>
              </Items>
            </RootViewItem>
          </Items>
        </RootViewItem>
      </Items>
      <DisplayName>Просмотр</DisplayName>
      <ReadOnly>true</ReadOnly>
    </FormViewItem>
  </Forms>
  <TableViews>
    <TableView>
      <Uid>4a482dc8-e1c7-44b9-a57b-cefcc44424a7</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <TitlePropertyUid>eeeb8ddd-eb36-4903-ad28-2f467dffd44e</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>59760e6a-3a97-4e9f-a608-d5d402150c2f</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>EmailMessage</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <Filterable>true</Filterable>
  <Filter />
  <Actions />
</Entity>